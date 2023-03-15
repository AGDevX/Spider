using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using AGDevX.Assemblies;
using AGDevX.Strings;

namespace AGDevX.Web.Exceptions;

public sealed class ExceptionDetail
{
    public required int HttpStatusCode { get; set; }
    public required string Code { get; set; }
    public required string Message { get; set; }
    public IEnumerable<StackFrameModel>? StackFrames { get; set; }
    public ExceptionDetail? InnerException { get; set; }
}

public class StackFrameModel
{
    public int LineNumber { get; set; }
    public string? Method { get; set; }
    public string? Class { get; set; }
    public string? AssemblyName { get; set; }
    public string? AssemblyFile { get; set; }
    public string? CodeFile { get; set; }
}

public static class ExceptionDetailExtensions
{
    //-- Inspired by https://stackoverflow.com/a/65972998/5372598

    public static ExceptionDetail CreateExceptionDetail(this Exception ex, int httpStatusCode, string code, bool includeStackFrames = true, bool filterStackFrames = false, IEnumerable<string>? assemblyPrefixes = default)
    {
        assemblyPrefixes ??= new List<string>();

        var stackTrace = new StackTrace(ex, true);

        var exceptionDetail = new ExceptionDetail
        {
            HttpStatusCode = httpStatusCode,
            Code = code,
            Message = ex.Message,
            StackFrames = includeStackFrames
                ? stackTrace.GetFrames().Select(sfm => new StackFrameModel
                {
                    LineNumber = sfm.GetFileLineNumber(),
                    Method = GetMethodSignature(sfm.GetMethod()),
                    Class = sfm.GetMethod()?.DeclaringType?.FullName,
                    AssemblyName = sfm.GetMethod()?.DeclaringType?.Assembly?.FullName,
                    AssemblyFile = sfm.GetMethod()?.DeclaringType?.Assembly?.Location,
                    CodeFile = sfm.GetFileName(),
                }).Where(sf => !(sf.Class?.ContainsIgnoreCase(nameof(AGDevX.Web.Exceptions.UnhandledExceptionMiddleware)) ?? false)
                    && (!filterStackFrames || (filterStackFrames && !assemblyPrefixes.Any() || AssemblyUtility.AssemblyNameStartsWithAnyPrefix(sf.AssemblyName, assemblyPrefixes))))
                : null
        };

        exceptionDetail.InnerException = ex?.InnerException?.CreateExceptionDetail(httpStatusCode, code) ?? null;

        return exceptionDetail;
    }

    private static string? GetMethodSignature(MethodBase? methodBase)
    {
        if (methodBase == null)
        {
            return null;
        }

        var methodSignatureStringBuilder = new StringBuilder(methodBase.Name);

        //-- Generic Method
        if (methodBase is MethodInfo && ((MethodInfo)methodBase).IsGenericMethod)
        {
            var genericArgs = ((MethodInfo)methodBase).GetGenericArguments();

            methodSignatureStringBuilder.Append("<");
            methodSignatureStringBuilder.Append(string.Join(", ", genericArgs.Select(ga => ga.Name)).Trim());
            methodSignatureStringBuilder.Append(">");
        }

        //-- Arguments
        var parameterInfos = methodBase.GetParameters();

        methodSignatureStringBuilder.Append("(");
        methodSignatureStringBuilder.Append(string.Join(", ", parameterInfos.Select(pi => $"{pi.ParameterType?.Name ?? "<unknown type>"} {pi.Name}")).Trim());
        methodSignatureStringBuilder.Append(")");

        return methodSignatureStringBuilder.ToString();
    }
}