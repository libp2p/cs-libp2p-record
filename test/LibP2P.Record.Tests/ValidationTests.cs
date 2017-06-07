using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibP2P.Crypto;
using Multiformats.Hash;
using Xunit;

namespace LibP2P.Record.Tests
{
    public class ValidationTests
    {
        [Fact]
        public void TestValidatePublicKey()
        {
            const string OffensiveKey = "CAASXjBcMA0GCSqGSIb3DQEBAQUAA0sAMEgCQQDjXAQQMal4SB2tSnX6NJIPmC69/BT8A8jc7/gDUZNkEhdhYHvc7k7S4vntV/c92nJGxNdop9fKJyevuNMuXhhHAgMBAAE=";
            var pkb = Convert.FromBase64String(OffensiveKey);
            var pubk = PublicKey.Unmarshal(pkb);
            var k = $"/pk/{Multihash.Cast(pubk.Hash)}";

            Assert.True(Validator.ValidatePublicKeyRecord(k, pkb));
        }
    }
}
