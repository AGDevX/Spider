using System;
using System.Collections.Generic;
using System.Linq;
using AGDevX.Exceptions;
using AGDevX.Objects;
using Xunit;

namespace AGDevX.Tests.Exceptions;

public sealed class ExceptionDetailTests
{
    private const string _applicationStartupExceptionMessage = "The application failed to start";
    private const string _extensionMethodExceptionMessage = "Unhandled scenario";
    private const string _nullReferenceExceptionMessage = "Dude, the object was null.";

    private static NullReferenceException? _nullReferenceException;
    private static ExtensionMethodException? _extensionMethodException;
    private static ApplicationStartupException? _applicationStartupException;

    private static List<string> _assemblyPrefixes = new List<string>() { "AGDevX", "JMC", "RD" };

    public class When_calling_GetExceptionDetail
    {
        public class And_including_stack_frames_and_filtering_stack_frames_for_a_generic_method
        {
            [Fact]
            public void Then_return_filtered_stack_frames()
            {
                //-- Arrange
                _nullReferenceException = new NullReferenceException(_nullReferenceExceptionMessage);
                _applicationStartupException = new ApplicationStartupException(_applicationStartupExceptionMessage, _nullReferenceException);

                bool includeStackFrames = true;
                bool filterStackFrames = true;

                //-- Act
                try
                {
                    void localF<T>()
                    {
                        throw _applicationStartupException!;
                    }

                    localF<object>();
                }
                catch (ApplicationStartupException appStartEx)
                {
                    var exceptionDetail = appStartEx.GetExceptionDetail(includeStackFrames, filterStackFrames, _assemblyPrefixes);

                    //-- Assert
                    Assert.True(exceptionDetail.Code.Equals(_applicationStartupException.Code));
                    Assert.True(exceptionDetail.Message.Equals(_applicationStartupException.Message));
                    Assert.True(exceptionDetail.StackFrames.IsNotNull());
                    Assert.IsType<int>(exceptionDetail.StackFrames.First().LineNumber);
                    Assert.True(exceptionDetail.StackFrames.First().Method!.Equals("localF<T>()"));
                    Assert.True(exceptionDetail.StackFrames.First().AssemblyFile!.Contains("AGDevX.Tests.dll"));
                    Assert.True(exceptionDetail.StackFrames.First().AssemblyName!.Contains("AGDevX.Tests"));
                    Assert.True(exceptionDetail.StackFrames.First().Class!.Equals("AGDevX.Tests.Exceptions.ExceptionDetailTests+When_calling_GetExceptionDetail+And_including_stack_frames_and_filtering_stack_frames_for_a_generic_method"));
                    Assert.True(exceptionDetail.StackFrames.First().CodeFile!.Contains("ExceptionDetailTests.cs"));
                    Assert.True(exceptionDetail.InnerException.IsNotNull());
                }


            }
        }

        public class And_including_stack_frames_and_filtering_stack_frames_for_a_non_generic_method
        {
            [Fact]
            public void Then_return_filtered_stack_frames()
            {
                //-- Arrange
                _nullReferenceException = new NullReferenceException(_nullReferenceExceptionMessage);
                _applicationStartupException = new ApplicationStartupException(_applicationStartupExceptionMessage, _nullReferenceException);

                bool includeStackFrames = true;
                bool filterStackFrames = true;

                //-- Act
                try
                {
                    throw _applicationStartupException;
                }
                catch (ApplicationStartupException appStartEx)
                {
                    var exceptionDetail = appStartEx.GetExceptionDetail(includeStackFrames, filterStackFrames, _assemblyPrefixes);

                    //-- Assert
                    Assert.True(exceptionDetail.Code.Equals(_applicationStartupException.Code));
                    Assert.True(exceptionDetail.Message.Equals(_applicationStartupException.Message));
                    Assert.True(exceptionDetail.StackFrames.IsNotNull());
                    Assert.IsType<int>(exceptionDetail.StackFrames.First().LineNumber);
                    Assert.True(exceptionDetail.StackFrames.First().Method!.Equals("Then_return_filtered_stack_frames()"));
                    Assert.True(exceptionDetail.StackFrames.First().AssemblyFile!.Contains("AGDevX.Tests.dll"));
                    Assert.True(exceptionDetail.StackFrames.First().AssemblyName!.Contains("AGDevX.Tests"));
                    Assert.True(exceptionDetail.StackFrames.First().Class!.Equals("AGDevX.Tests.Exceptions.ExceptionDetailTests+When_calling_GetExceptionDetail+And_including_stack_frames_and_filtering_stack_frames_for_a_non_generic_method"));
                    Assert.True(exceptionDetail.StackFrames.First().CodeFile!.Contains("ExceptionDetailTests.cs"));
                    Assert.True(exceptionDetail.InnerException.IsNotNull());
                }
            }
        }

        public class And_including_stack_frames_and_filtering_stack_frames_for_a_method_name_ending_in_a_symbol
        {
            [Fact]
            public void GetExceptionDetail_()
            {
                //-- Arrange
                _extensionMethodException = new ExtensionMethodException(_extensionMethodExceptionMessage);
                _applicationStartupException = new ApplicationStartupException(_extensionMethodExceptionMessage, _extensionMethodException);

                bool includeStackFrames = true;
                bool filterStackFrames = true;

                //-- Act
                var exceptionDetail = _applicationStartupException.GetExceptionDetail(includeStackFrames, filterStackFrames);

                //-- Assert
                Assert.True(exceptionDetail.Code.Equals(_applicationStartupException.Code));
                Assert.True(exceptionDetail.Message.Equals(_applicationStartupException.Message));
                Assert.True(exceptionDetail.StackFrames.IsNotNull());
                Assert.True(exceptionDetail.InnerException.IsNotNull());
            }
        }

        public class And_not_including_stack_frames
        {
            [Fact]
            public void Then_do_not_return_stack_frames()
            {
                //-- Arrange
                _nullReferenceException = new NullReferenceException(_nullReferenceExceptionMessage);
                _applicationStartupException = new ApplicationStartupException(_applicationStartupExceptionMessage, _nullReferenceException);

                bool includeStackFrames = false;
                bool filterStackFrames = true;

                //-- Act
                try
                {
                    throw _applicationStartupException;
                }
                catch (ApplicationStartupException appStartEx)
                {
                    var exceptionDetail = appStartEx.GetExceptionDetail(includeStackFrames, filterStackFrames, _assemblyPrefixes);

                    //-- Assert
                    Assert.True(exceptionDetail.Code.Equals(_applicationStartupException.Code));
                    Assert.True(exceptionDetail.Message.Equals(_applicationStartupException.Message));
                    Assert.True(exceptionDetail.StackFrames.IsNull());
                    Assert.True(exceptionDetail.InnerException.IsNotNull());
                }
            }
        }
    }
}