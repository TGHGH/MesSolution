﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GMF.Demo.Core.Data.Initialize;

namespace UnitTestForm.Service
{
    [TestClass]
    public class UnitTestBase
    {
        public UnitTestBase()
        {
            DatabaseInitializer.DropCreateDatabaseIfModelChanges();
        }
      
    }
}