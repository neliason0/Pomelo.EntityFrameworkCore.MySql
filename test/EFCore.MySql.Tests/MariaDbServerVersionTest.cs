// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Pomelo.EntityFrameworkCore.MySql
{
    public class MariaDbServerVersionTest
    {
        public static TheoryData<string, bool> SpatialDistanceSphereFunctionVersionSupportedData =>
            new()
            {
            {"10.7.0", true},
            {"10.6.1", true},
            {"10.6.0", true},
            {"10.5.11", true}, // 10.5
            {"10.5.10", true},
            {"10.5.9", false},
            {"10.5.0", false},
            {"10.4.20", true}, // 10.4
            {"10.4.19", true},
            {"10.4.18", false},
            {"10.4.0", false},
            {"10.3.30", true}, // 10.3
            {"10.3.29", true},
            {"10.3.28", false},
            {"10.3.0", false},
            {"10.2.40", true}, // 10.2
            {"10.2.38", true},
            {"10.2.37", false},
            {"10.2.0", false},
            {"10.1.0", false}, // 10.1
            };

        [Theory]
        [MemberData(nameof(SpatialDistanceSphereFunctionVersionSupportedData))]
        public void SpatialDistanceSphereFunction_with_Versions_ShouldBe(string versionText, bool supports)
        {
            var version = new MariaDbServerVersion(versionText);

            Assert.Equal(supports, version.Supports.SpatialDistanceSphereFunction);
        }
    }
}