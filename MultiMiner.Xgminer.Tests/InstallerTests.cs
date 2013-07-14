﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MultiMiner.Xgminer.Tests
{
    [TestClass]
    public class InstallerTests
    {
        [TestMethod]
        public void InstallMiner_Cgminer_InstallsCgminer()
        {
            //arrange
            string tempPath = System.IO.Path.GetTempPath();
            string minerPath = Path.Combine(tempPath, Guid.NewGuid().ToString());
            Directory.CreateDirectory(minerPath);
            string executablePath = Path.Combine(minerPath, "cgminer.exe");

            //act
            Xgminer.Installer.InstallMiner(MinerBackend.Cgminer, minerPath);

            //assert
            Assert.IsTrue(File.Exists(executablePath));

            //cleanup
            Directory.Delete(minerPath, true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void InstallMiner_Bfgminer_ThrowsNotImplemented()
        {
            Xgminer.Installer.InstallMiner(MinerBackend.Bfgminer, "");
        }
    }
}