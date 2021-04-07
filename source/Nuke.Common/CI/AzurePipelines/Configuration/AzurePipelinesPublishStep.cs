﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesPublishStep : AzurePipelinesStep
    {
        public string ArtifactName { get; set; }
        public string PathToPublish { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: PublishBuildArtifacts@1"))
            {
                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine($"artifactName: {ArtifactName}");
                    writer.WriteLine($"pathtoPublish: {PathToPublish.SingleQuote()}");
                }
            }
        }
    }
}
