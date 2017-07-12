// Type: System.Net.HttpWebRequest
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Net.Cache;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Net
{
    /// <summary>
    /// Provides an HTTP-specific implementation of the <see cref="T:System.Net.WebRequest"/> class.
    /// </summary>
    [Serializable]
    public class HttpWebRequest : WebRequest, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Net.HttpWebRequest"/> class.
        /// </summary>
        [Obsolete("This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HttpWebRequest();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Net.HttpWebRequest"/> class from the specified instances of the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> and <see cref="T:System.Runtime.Serialization.StreamingContext"/> classes.
        /// </summary>
        /// <param name="serializationInfo">A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object that contains the information required to serialize the new <see cref="T:System.Net.HttpWebRequest"/> object. </param><param name="streamingContext">A <see cref="T:System.Runtime.Serialization.StreamingContext"/> object that contains the source and destination of the serialized stream associated with the new <see cref="T:System.Net.HttpWebRequest"/> object. </param>
        [Obsolete("Serialization is obsoleted for this type.  http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected HttpWebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext);

        /// <summary>
        /// Begins an asynchronous request for a <see cref="T:System.IO.Stream"/> object to use to write data.
        /// </summary>
        /// <param name="callback">The <see cref="T:System.AsyncCallback"/> delegate. </param><param name="state">The state object for this request. </param>
        /// <returns>
        /// An <see cref="T:System.IAsyncResult"/> that references the asynchronous request.
        /// </returns>
        /// <exception cref="T:System.Net.ProtocolViolationException">The <see cref="P:System.Net.HttpWebRequest.Method"/> property is GET or HEAD.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false, and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT. </exception><exception cref="T:System.InvalidOperationException">The stream is being used by a previous call to <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false.-or- The thread pool is running out of threads. </exception><exception cref="T:System.NotSupportedException">The request cache validator indicated that the response for this request can be served from the cache; however, requests that write data must not use the cache. This exception can occur if you are using a custom cache validator that is incorrectly implemented. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called. </exception><exception cref="T:System.ObjectDisposedException">In a .NET Compact Framework application, a request stream with zero content length was not obtained and closed correctly. For more information about handling zero content length requests, see Network Programming in the .NET Compact Framework.</exception>
        [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
        public override IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for a <see cref="T:System.IO.Stream"/> object to use to write data.
        /// </summary>
        /// <param name="asyncResult">The pending request for a stream. </param>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> to use to write request data.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="asyncResult"/> is null. </exception><exception cref="T:System.IO.IOException">The request did not complete, and no stream is available. </exception><exception cref="T:System.ArgumentException"><paramref name="asyncResult"/> was not returned by the current instance from a call to <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>. </exception><exception cref="T:System.InvalidOperationException">This method was called previously using <paramref name="asyncResult"/>. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- An error occurred while processing the request. </exception>
        public override Stream EndGetRequestStream(IAsyncResult asyncResult);

        /// <summary>
        /// Ends an asynchronous request for a <see cref="T:System.IO.Stream"/> object to use to write data and outputs the <see cref="T:System.Net.TransportContext"/> associated with the stream.
        /// </summary>
        /// <param name="asyncResult">The pending request for a stream.</param><param name="context">The <see cref="T:System.Net.TransportContext"/> for the <see cref="T:System.IO.Stream"/>.</param>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> to use to write request data.
        /// </returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="asyncResult"/> was not returned by the current instance from a call to <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>. </exception><exception cref="T:System.ArgumentNullException"><paramref name="asyncResult"/> is null. </exception><exception cref="T:System.InvalidOperationException">This method was called previously using <paramref name="asyncResult"/>. </exception><exception cref="T:System.IO.IOException">The request did not complete, and no stream is available. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- An error occurred while processing the request. </exception>
        public Stream EndGetRequestStream(IAsyncResult asyncResult, out TransportContext context);

        /// <summary>
        /// Gets a <see cref="T:System.IO.Stream"/> object to use to write request data.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> to use to write request data.
        /// </returns>
        /// <exception cref="T:System.Net.ProtocolViolationException">The <see cref="P:System.Net.HttpWebRequest.Method"/> property is GET or HEAD.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false, and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT. </exception><exception cref="T:System.InvalidOperationException">The <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> method is called more than once.-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false. </exception><exception cref="T:System.NotSupportedException">The request cache validator indicated that the response for this request can be served from the cache; however, requests that write data must not use the cache. This exception can occur if you are using a custom cache validator that is incorrectly implemented. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- The time-out period for the request expired.-or- An error occurred while processing the request. </exception><exception cref="T:System.ObjectDisposedException">In a .NET Compact Framework application, a request stream with zero content length was not obtained and closed correctly. For more information about handling zero content length requests, see Network Programming in the .NET Compact Framework.</exception>
        public override Stream GetRequestStream();

        /// <summary>
        /// Gets a <see cref="T:System.IO.Stream"/> object to use to write request data and outputs the <see cref="T:System.Net.TransportContext"/> associated with the stream.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Net.TransportContext"/> for the <see cref="T:System.IO.Stream"/>.</param>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> to use to write request data.
        /// </returns>
        /// <exception cref="T:System.Exception">The <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> method was unable to obtain the <see cref="T:System.IO.Stream"/>.</exception><exception cref="T:System.InvalidOperationException">The <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> method is called more than once.-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false. </exception><exception cref="T:System.NotSupportedException">The request cache validator indicated that the response for this request can be served from the cache; however, requests that write data must not use the cache. This exception can occur if you are using a custom cache validator that is incorrectly implemented. </exception><exception cref="T:System.Net.ProtocolViolationException">The <see cref="P:System.Net.HttpWebRequest.Method"/> property is GET or HEAD.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false, and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- The time-out period for the request expired.-or- An error occurred while processing the request. </exception>
        public Stream GetRequestStream(out TransportContext context);

        /// <summary>
        /// Begins an asynchronous request to an Internet resource.
        /// </summary>
        /// <param name="callback">The <see cref="T:System.AsyncCallback"/> delegate </param><param name="state">The state object for this request. </param>
        /// <returns>
        /// An <see cref="T:System.IAsyncResult"/> that references the asynchronous request for a response.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The stream is already in use by a previous call to <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/>-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false.-or- The thread pool is running out of threads. </exception><exception cref="T:System.Net.ProtocolViolationException"><see cref="P:System.Net.HttpWebRequest.Method"/> is GET or HEAD, and either <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is greater than zero or <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is true.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, and either <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT.-or- The <see cref="T:System.Net.HttpWebRequest"/> has an entity body but the <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/> method is called without calling the <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/> method. -or- The <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is greater than zero, but the application does not write all of the promised data.</exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called. </exception>
        [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request to an Internet resource.
        /// </summary>
        /// <param name="asyncResult">The pending request for a response. </param>
        /// <returns>
        /// A <see cref="T:System.Net.WebResponse"/> that contains the response from the Internet resource.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="asyncResult"/> is null. </exception><exception cref="T:System.InvalidOperationException">This method was called previously using <paramref name="asyncResult."/>-or- The <see cref="P:System.Net.HttpWebRequest.ContentLength"/> property is greater than 0 but the data has not been written to the request stream. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- An error occurred while processing the request. </exception><exception cref="T:System.ArgumentException"><paramref name="asyncResult"/> was not returned by the current instance from a call to <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/>. </exception>
        public override WebResponse EndGetResponse(IAsyncResult asyncResult);

        /// <summary>
        /// Returns a response from an Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Net.WebResponse"/> that contains the response from the Internet resource.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The stream is already in use by a previous call to <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/>.-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false. </exception><exception cref="T:System.Net.ProtocolViolationException"><see cref="P:System.Net.HttpWebRequest.Method"/> is GET or HEAD, and either <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is greater or equal to zero or <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is true.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false, and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT. -or- The <see cref="T:System.Net.HttpWebRequest"/> has an entity body but the <see cref="M:System.Net.HttpWebRequest.GetResponse"/> method is called without calling the <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> method. -or- The <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is greater than zero, but the application does not write all of the promised data.</exception><exception cref="T:System.NotSupportedException">The request cache validator indicated that the response for this request can be served from the cache; however, this request includes data to be sent to the server. Requests that send data must not use the cache. This exception can occur if you are using a custom cache validator that is incorrectly implemented. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- The time-out period for the request expired.-or- An error occurred while processing the request. </exception>
        public override WebResponse GetResponse();

        /// <summary>
        /// Cancels a request to an Internet resource.
        /// </summary>
        public override void Abort();

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data. </param><param name="streamingContext">A <see cref="T:System.Runtime.Serialization.StreamingContext"/> that specifies the destination for this serialization.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext);

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data required to serialize the target object.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data. </param><param name="streamingContext">A <see cref="T:System.Runtime.Serialization.StreamingContext"/> that specifies the destination for this serialization.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext);

        /// <summary>
        /// Adds a byte range header to the request for a specified range.
        /// </summary>
        /// <param name="from">The position at which to start sending data. </param><param name="to">The position at which to stop sending data. </param><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="from"/> is greater than <paramref name="to"/>-or- <paramref name="from"/> or <paramref name="to"/> is less than 0. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(int from, int to);

        /// <summary>
        /// Adds a byte range header to the request for a specified range.
        /// </summary>
        /// <param name="from">The position at which to start sending data.</param><param name="to">The position at which to stop sending data.</param><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="from"/> is greater than <paramref name="to"/>-or- <paramref name="from"/> or <paramref name="to"/> is less than 0. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(long from, long to);

        /// <summary>
        /// Adds a byte range header to a request for a specific range from the beginning or end of the requested data.
        /// </summary>
        /// <param name="range">The starting or ending point of the range. </param><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(int range);

        /// <summary>
        /// Adds a byte range header to a request for a specific range from the beginning or end of the requested data.
        /// </summary>
        /// <param name="range">The starting or ending point of the range.</param><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(long range);

        /// <summary>
        /// Adds a range header to a request for a specified range.
        /// </summary>
        /// <param name="rangeSpecifier">The description of the range. </param><param name="from">The position at which to start sending data. </param><param name="to">The position at which to stop sending data. </param><exception cref="T:System.ArgumentNullException"><paramref name="rangeSpecifier"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="from"/> is greater than <paramref name="to"/>-or- <paramref name="from"/> or <paramref name="to"/> is less than 0. </exception><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(string rangeSpecifier, int from, int to);

        /// <summary>
        /// Adds a range header to a request for a specified range.
        /// </summary>
        /// <param name="rangeSpecifier">The description of the range.</param><param name="from">The position at which to start sending data.</param><param name="to">The position at which to stop sending data.</param><exception cref="T:System.ArgumentNullException"><paramref name="rangeSpecifier"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="from"/> is greater than <paramref name="to"/>-or- <paramref name="from"/> or <paramref name="to"/> is less than 0. </exception><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(string rangeSpecifier, long from, long to);

        /// <summary>
        /// Adds a Range header to a request for a specific range from the beginning or end of the requested data.
        /// </summary>
        /// <param name="rangeSpecifier">The description of the range. </param><param name="range">The starting or ending point of the range. </param><exception cref="T:System.ArgumentNullException"><paramref name="rangeSpecifier"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(string rangeSpecifier, int range);

        /// <summary>
        /// Adds a Range header to a request for a specific range from the beginning or end of the requested data.
        /// </summary>
        /// <param name="rangeSpecifier">The description of the range.</param><param name="range">The starting or ending point of the range.</param><exception cref="T:System.ArgumentNullException"><paramref name="rangeSpecifier"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="rangeSpecifier"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The range header could not be added. </exception>
        public void AddRange(string rangeSpecifier, long range);

        /// <summary>
        /// Gets or sets a value that indicates whether the request should follow redirection responses.
        /// </summary>
        /// 
        /// <returns>
        /// true if the request should automatically follow redirection responses from the Internet resource; otherwise, false. The default value is true.
        /// </returns>
        public virtual bool AllowAutoRedirect { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to buffer the data sent to the Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// true to enable buffering of the data sent to the Internet resource; false to disable buffering. The default is true.
        /// </returns>
        public virtual bool AllowWriteStreamBuffering { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to buffer the received from the Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// true to buffer the received from the Internet resource; otherwise, false.true to enable buffering of the data received from the Internet resource; false to disable buffering. The default is false.
        /// </returns>
        public virtual bool AllowReadStreamBuffering { get; set; }

        /// <summary>
        /// Gets a value that indicates whether a response has been received from an Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// true if a response has been received; otherwise, false.
        /// </returns>
        public virtual bool HaveResponse { get; }

        /// <summary>
        /// Gets or sets a value that indicates whether to make a persistent connection to the Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// true if the request to the Internet resource should contain a Connection HTTP header with the value Keep-alive; otherwise, false. The default is true.
        /// </returns>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to pipeline the request to the Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// true if the request should be pipelined; otherwise, false. The default is true.
        /// </returns>
        public bool Pipelined { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to send an Authorization header with the request.
        /// </summary>
        /// 
        /// <returns>
        /// true to send an  HTTP Authorization header with requests after authentication has taken place; otherwise, false. The default is false.
        /// </returns>
        public override bool PreAuthenticate { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to allow high-speed NTLM-authenticated connection sharing.
        /// </summary>
        /// 
        /// <returns>
        /// true to keep the authenticated connection open; otherwise, false.
        /// </returns>
        public bool UnsafeAuthenticatedConnectionSharing { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to send data in segments to the Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// true to send data to the Internet resource in segments; otherwise, false. The default value is false.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The request has been started by calling the <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/>, <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>, <see cref="M:System.Net.HttpWebRequest.GetResponse"/>, or <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/> method. </exception>
        public bool SendChunked { get; set; }

        /// <summary>
        /// Gets or sets the type of decompression that is used.
        /// </summary>
        /// 
        /// <returns>
        /// A T:System.Net.DecompressionMethods object that indicates the type of decompression that is used.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The object's current state does not allow this property to be set.</exception>
        public DecompressionMethods AutomaticDecompression { get; set; }

        /// <summary>
        /// Gets or sets the default cache policy for this request.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Net.Cache.HttpRequestCachePolicy"/> that specifies the cache policy in effect for this request when no other policy is applicable.
        /// </returns>
        public new static RequestCachePolicy DefaultCachePolicy { get; set; }

        /// <summary>
        /// Gets or sets the default for the <see cref="P:System.Net.HttpWebRequest.MaximumResponseHeadersLength"/> property.
        /// </summary>
        /// 
        /// <returns>
        /// The length, in kilobytes (1024 bytes), of the default maximum for response headers received. The default configuration file sets this value to 64 kilobytes.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value is not equal to -1 and is less than zero. </exception>
        public static int DefaultMaximumResponseHeadersLength { get; set; }

        /// <summary>
        /// Gets or sets the default maximum length of an HTTP error response.
        /// </summary>
        /// 
        /// <returns>
        /// The default maximum length of an HTTP error response.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 0 and is not equal to -1. </exception>
        public static int DefaultMaximumErrorResponseLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowed length of the response headers.
        /// </summary>
        /// 
        /// <returns>
        /// The length, in kilobytes (1024 bytes), of the response headers.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The property is set after the request has already been submitted. </exception><exception cref="T:System.ArgumentOutOfRangeException">The value is less than 0 and is not equal to -1. </exception>
        public int MaximumResponseHeadersLength { get; set; }

        /// <summary>
        /// Gets or sets the collection of security certificates that are associated with this request.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Security.Cryptography.X509Certificates.X509CertificateCollection"/> that contains the security certificates associated with this request.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The value specified for a set operation is null. </exception>
        public X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        /// Gets or sets the cookies associated with the request.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Net.CookieContainer"/> that contains the cookies associated with this request.
        /// </returns>
        public virtual CookieContainer CookieContainer { get; set; }

        /// <summary>
        /// Gets a value that indicates whether the request provides support for a <see cref="T:System.Net.CookieContainer"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the request provides support for a <see cref="T:System.Net.CookieContainer"/>; otherwise, false.true if a <see cref="T:System.Net.CookieContainer"/> is supported; otherwise, false.
        /// </returns>
        public virtual bool SupportsCookieContainer { get; }

        /// <summary>
        /// Gets the original Uniform Resource Identifier (URI) of the request.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Uri"/> that contains the URI of the Internet resource passed to the <see cref="M:System.Net.WebRequest.Create(System.String)"/> method.
        /// </returns>
        public override Uri RequestUri { get; }

        /// <summary>
        /// Gets or sets the Content-length HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The number of bytes of data to send to the Internet resource. The default is -1, which indicates the property has not been set and that there is no request data to send.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The request has been started by calling the <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/>, <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>, <see cref="M:System.Net.HttpWebRequest.GetResponse"/>, or <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/> method. </exception><exception cref="T:System.ArgumentOutOfRangeException">The new <see cref="P:System.Net.HttpWebRequest.ContentLength"/> value is less than 0. </exception>
        public override long ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the time-out value in milliseconds for the <see cref="M:System.Net.HttpWebRequest.GetResponse"/> and <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> methods.
        /// </summary>
        /// 
        /// <returns>
        /// The number of milliseconds to wait before the request times out. The default value is 100,000 milliseconds (100 seconds).
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value specified is less than zero and is not <see cref="F:System.Threading.Timeout.Infinite"/>.</exception>
        public override int Timeout { get; set; }

        /// <summary>
        /// Gets or sets a time-out in milliseconds when writing to or reading from a stream.
        /// </summary>
        /// 
        /// <returns>
        /// The number of milliseconds before the writing or reading times out. The default value is 300,000 milliseconds (5 minutes).
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The request has already been sent. </exception><exception cref="T:System.ArgumentOutOfRangeException">The value specified for a set operation is less than or equal to zero and is not equal to <see cref="F:System.Threading.Timeout.Infinite"/></exception>
        public int ReadWriteTimeout { get; set; }

        /// <summary>
        /// Gets or sets a timeout, in milliseconds, to wait until the 100-Continue is received from the server.
        /// </summary>
        /// 
        /// <returns>
        /// The timeout, in milliseconds, to wait until the 100-Continue is received.
        /// </returns>
        public int ContinueTimeout { get; set; }

        /// <summary>
        /// Gets the Uniform Resource Identifier (URI) of the Internet resource that actually responds to the request.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Uri"/> that identifies the Internet resource that actually responds to the request. The default is the URI used by the <see cref="M:System.Net.WebRequest.Create(System.String)"/> method to initialize the request.
        /// </returns>
        public Uri Address { get; }

        /// <summary>
        /// Gets or sets the delegate method called when an HTTP 100-continue response is received from the Internet resource.
        /// </summary>
        /// 
        /// <returns>
        /// A delegate that implements the callback method that executes when an HTTP Continue response is returned from the Internet resource. The default value is null.
        /// </returns>
        public HttpContinueDelegate ContinueDelegate { get; set; }

        /// <summary>
        /// Gets the service point to use for the request.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Net.ServicePoint"/> that represents the network connection to the Internet resource.
        /// </returns>
        public ServicePoint ServicePoint { get; }

        /// <summary>
        /// Get or set the Host header value to use in an HTTP request independent from the request URI.
        /// </summary>
        /// 
        /// <returns>
        /// The Host header value in the HTTP request.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The Host header cannot be set to null. </exception><exception cref="T:System.ArgumentException">The Host header cannot be set to an invalid value. </exception><exception cref="T:System.InvalidOperationException">The Host header cannot be set after the <see cref="T:System.Net.HttpWebRequest"/> has already started to be sent. </exception>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of redirects that the request follows.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum number of redirection responses that the request follows. The default value is 50.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The value is set to 0 or less. </exception>
        public int MaximumAutomaticRedirections { get; set; }

        /// <summary>
        /// Gets or sets the method for the request.
        /// </summary>
        /// 
        /// <returns>
        /// The request method to use to contact the Internet resource. The default value is GET.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">No method is supplied.-or- The method string contains invalid characters. </exception>
        public override string Method { get; set; }

        /// <summary>
        /// Gets or sets authentication information for the request.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Net.ICredentials"/> that contains the authentication credentials associated with the request. The default is null.
        /// </returns>
        public override ICredentials Credentials { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Boolean"/> value that controls whether default credentials are sent with requests.
        /// </summary>
        /// 
        /// <returns>
        /// true if the default credentials are used; otherwise false. The default value is false.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">You attempted to set this property after the request was sent.</exception>
        public override bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// Gets or sets the name of the connection group for the request.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the connection group for this request. The default value is null.
        /// </returns>
        public override string ConnectionGroupName { get; set; }

        /// <summary>
        /// Specifies a collection of the name/value pairs that make up the HTTP headers.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Net.WebHeaderCollection"/> that contains the name/value pairs that make up the headers for the HTTP request.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The request has been started by calling the <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/>, <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>, <see cref="M:System.Net.HttpWebRequest.GetResponse"/>, or <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/> method. </exception>
        public override WebHeaderCollection Headers { get; set; }

        /// <summary>
        /// Gets or sets proxy information for the request.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Net.IWebProxy"/> object to use to proxy the request. The default value is set by calling the <see cref="P:System.Net.GlobalProxySelection.Select"/> property.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException"><see cref="P:System.Net.HttpWebRequest.Proxy"/> is set to null. </exception><exception cref="T:System.InvalidOperationException">The request has been started by calling <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/>, <see cref="M:System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object)"/>, <see cref="M:System.Net.HttpWebRequest.GetResponse"/>, or <see cref="M:System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)"/>. </exception><exception cref="T:System.Security.SecurityException">The caller does not have permission for the requested operation. </exception>
        public override IWebProxy Proxy { get; set; }

        /// <summary>
        /// Gets or sets the version of HTTP to use for the request.
        /// </summary>
        /// 
        /// <returns>
        /// The HTTP version to use for the request. The default is <see cref="F:System.Net.HttpVersion.Version11"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The HTTP version is set to a value other than 1.0 or 1.1. </exception>
        public Version ProtocolVersion { get; set; }

        /// <summary>
        /// Gets or sets the value of the Content-type HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the Content-type HTTP header. The default value is null.
        /// </returns>
        public override string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the media type of the request.
        /// </summary>
        /// 
        /// <returns>
        /// The media type of the request. The default value is null.
        /// </returns>
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or sets the value of the Transfer-encoding HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the Transfer-encoding HTTP header. The default value is null.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set when <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false. </exception><exception cref="T:System.ArgumentException"><see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to the value "Chunked". </exception>
        public string TransferEncoding { get; set; }

        /// <summary>
        /// Gets or sets the value of the Connection HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the Connection HTTP header. The default value is null.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The value of <see cref="P:System.Net.HttpWebRequest.Connection"/> is set to Keep-alive or Close. </exception>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the value of the Accept HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the Accept HTTP header. The default value is null.
        /// </returns>
        public string Accept { get; set; }

        /// <summary>
        /// Gets or sets the value of the Referer HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the Referer HTTP header. The default value is null.
        /// </returns>
        public string Referer { get; set; }

        /// <summary>
        /// Gets or sets the value of the User-agent HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the User-agent HTTP header. The default value is null.The value for this property is stored in <see cref="T:System.Net.WebHeaderCollection"/>. If WebHeaderCollection is set, the property value is lost.
        /// </returns>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the value of the Expect HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// The contents of the Expect HTTP header. The default value is null.The value for this property is stored in <see cref="T:System.Net.WebHeaderCollection"/>. If WebHeaderCollection is set, the property value is lost.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">Expect is set to a string that contains "100-continue" as a substring. </exception>
        public string Expect { get; set; }

        /// <summary>
        /// Gets or sets the value of the If-Modified-Since HTTP header.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.DateTime"/> that contains the contents of the If-Modified-Since HTTP header. The default value is the current date and time.
        /// </returns>
        public DateTime IfModifiedSince { get; set; }

        /// <summary>
        /// Get or set the Date HTTP header value to use in an HTTP request.
        /// </summary>
        /// 
        /// <returns>
        /// The Date header value in the HTTP request.
        /// </returns>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets a callback function to validate the server certificate.
        /// </summary>
        /// 
        /// <returns>
        /// A callback function to validate the server certificate.A callback function to validate the server certificate.
        /// </returns>
        public RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; }
    }
}
