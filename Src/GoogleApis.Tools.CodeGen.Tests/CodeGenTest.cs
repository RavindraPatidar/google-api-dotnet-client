/*
Copyright 2010 Google Inc

Licensed under the Apache License, Version 2.0 (the ""License"");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an ""AS IS"" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;

using NUnit.Framework;
using log4net;

using Google.Apis.Discovery;


namespace Google.Apis.Tools.CodeGen.Tests
{
	[TestFixture()]
	public class CodeGenTest :BaseCodeGeneratorTest
	{
		/// <summary>
		/// Tests if the code generated by CodeGen Compiles, fails if it does not.
		/// </summary>
		[Test()]
		public void TestCompilationWithDefaultDecorators ()
		{
			var clientNamespace ="Google.Apis.Samples.CommandLineGeneratedService.Buzz";
			
			string cacheDirectory = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
			    "GoogleApis.Tools.CodeGenCache");
			
			if(Directory.Exists(cacheDirectory) == false){
				Directory.CreateDirectory(cacheDirectory);
			}
			
			var service = CreateBuzzService();
			
			var generator = new CodeGen(service, clientNamespace);	
			var codeCompileUnit = generator.GenerateCode ();
			
			// Full Compile we should not have any warnings.
			CheckCompile(codeCompileUnit, true, "Failed To compile resultant code with default decorators.");
		}
	}
}