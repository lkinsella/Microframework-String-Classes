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
 */

using System;
using System.Text;

namespace System.Text
{

    public static class StringUtils
    {

        public static bool StartsWith(string s, string term)
        {
            if (s.Length < term.Length) return false;

            if (s.Length == term.Length) {
                return (s == term);
            }

            for(int i = 0; i < term.Length; i++) {
                if (s[i] != term[i]) return false;
            }

            return true;
        }

        public static string Replace(string s, string term, string replacement)
        {
            int start = 0;
            int term_length = term.Length;
            int first = s.IndexOf(term,start);

            StringBuilder builder = new StringBuilder();

            string buffer = s;

            while ((first = buffer.IndexOf(term,start)) >= 0) {
                builder.Append(buffer.Substring(0,first));
                builder.Append(replacement);

                buffer = buffer.Substring(first + term_length,buffer.Length - (first + term_length));
            }

            builder.Append(buffer);

            return builder.ToString();

        }

    }

}
