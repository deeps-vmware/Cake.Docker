﻿using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;
using System;

namespace Cake.Docker.Tests.Up
{
    public class DockerComposeUpFixture : ToolFixture<DockerComposeUpSettings>, ICakeContext
    {
        public string Service { get; set; }

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => throw new NotImplementedException();

        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

        public DockerComposeUpFixture(): base("docker-compose")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.DockerComposeUp(Settings, Service);
            if(string.IsNullOrEmpty(Service))
            {
                this.DockerComposeUp(Settings);
            }
        }
    }
}
