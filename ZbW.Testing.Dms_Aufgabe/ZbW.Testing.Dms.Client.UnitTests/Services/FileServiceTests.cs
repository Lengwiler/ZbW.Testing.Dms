using System;
using FakeItEasy;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.Services
{
    [TestFixture]
    internal class FileServiceTests
    {
        [Test]
        public void OnCmdSpeichern_ValutaDatumIsNull_ThrowsException()
        {
            const string repositoryDir = @"C:\Temp\DMS";

            const string bezeichnung = "Test Bezeichnung";

            const string benutzer = "Test Benutzer";

            const string selectedTypItem = "Verträge";

            var erfassungsdatum = System.DateTime.Parse("2018-01-01");

            const bool isRemoveFileEnabled = false;

            var metaDataItemFake = A.Fake<MetadataItem>();

            // arrange
            var fileService = new FileService();

            // assert
            Assert.Throws(typeof(Exception) ,delegate
            {
                fileService.Save(repositoryDir, null, null, bezeichnung, selectedTypItem, erfassungsdatum, benutzer, isRemoveFileEnabled, metaDataItemFake);
            });
        }
    }
}
