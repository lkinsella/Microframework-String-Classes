/*
 * Copyright (C)2011 by Lloyd Kinsella (http://www.lloydkinsella.net/).
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * 
 */

using System;
using System.Collections;
using System.Text;

namespace System.Text
{

    public class StringBuilder : IDisposable
    {

        private bool disposed;
        private ArrayList buffer;

        public StringBuilder()
        {
            disposed = false;
            buffer = new ArrayList();
        }

        public StringBuilder(string str) : this()
        {
            Append(str);
        }

        public StringBuilder(char[] chars) : this()
        {
            Append(chars);
        }

        public void Dispose()
        {
            if (!disposed) {
                // Clear out buffer
                buffer.Clear();
                buffer = null;

                // Run GC
                Debug.GC(true);

                // Mark as disposed
                disposed = true;
            }
        }

        #region Methods

        public void Clear()
        {
            if (disposed) throw new ObjectDisposedException();

            buffer.Clear();
        }

        public void Append(char c)
        {
            if (disposed) throw new ObjectDisposedException();

            buffer.Add(c);
        }

        public void Append(string str)
        {
            foreach(char c in str) Append(c);
        }

        public void Append(char[] chars)
        {
            foreach(char c in chars) Append(c);
        }

        public void AppendLine(char c)
        {
            Append(c);
            Append("\r\n");
        }

        public void AppendLine(string str)
        {
            Append(str);
            Append("\r\n");
        }

        public void AppendLine(char[] chars)
        {
            Append(chars);
            Append("\r\n");
        }

        public override string ToString()
        {
            if (disposed) throw new ObjectDisposedException();

            return new String((char[])buffer.ToArray(typeof(char)));
        }

        #endregion

        #region Properties

        public int Length
        {
            get {
                if (disposed) throw new ObjectDisposedException();

                return buffer.Count;
            }
        }

        public char this[int index]
        {
            get {
                if (disposed) throw new ObjectDisposedException();

                return (char)buffer[index];
            }
        }

        #endregion

    }

}
