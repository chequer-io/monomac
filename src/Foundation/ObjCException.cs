//
// Copyright 2013, Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace MonoMac.Foundation {
	public class ObjCException : Exception {
		NSException native_exc;
		string _stackTrace;

		public ObjCException () : base ()
		{
			native_exc = new NSException ("default", String.Empty, null);
		}

		public ObjCException (NSException exc) : base ()
		{
			native_exc = exc;
		}

		public ObjCException (NSException exc, string stackTrace)
		{
			native_exc = exc;
			_stackTrace = stackTrace;
		}

		[Preserve]
		internal static void Throw (IntPtr handle)
		{
			throw new ObjCException (new NSException (handle));
		}

		public NSException NSException => native_exc;

		public string Reason => native_exc.Reason;

		public string Name => native_exc.Name;

		public override string StackTrace => _stackTrace ?? base.StackTrace;

		public override string Message => $"{Name}: {Reason}";
	}
}
