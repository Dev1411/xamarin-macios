// 
// CALayerDelegate.cs
//
// Authors:
//   Rolf Bjarne Kvinge
//     
// Copyright 2014 Xamarin Inc
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

using XamCore.Foundation; 
using XamCore.ObjCRuntime;
using XamCore.CoreGraphics;

namespace XamCore.CoreAnimation {

	public unsafe partial class CALayerDelegate {
		IntPtr calayer;

		internal void SetCALayer (CALayer layer)
		{
			calayer = layer == null ? IntPtr.Zero : layer.Handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (calayer != IntPtr.Zero)
				Messaging.void_objc_msgSend_IntPtr (calayer, Selector.GetHandle ("setDelegate:"), IntPtr.Zero);

			base.Dispose (disposing);
		}
	}
}