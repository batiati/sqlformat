﻿using System;
using System.Linq;

using MbUnit.Framework;

namespace Laan.SQL.Parser.Test
{
    [TestFixture]
    public class TestBatchTerminators
    {
        [Test]
        public void Test_Statements_With_Semicolon_Terminators()
        {
            // Exercise
            var statements = ParserFactory.Execute( @"

               SELECT 1;
               UPDATE dbo.Table SET Fields = 1;
               DELETE FROM dbo.Table WHERE ID < 10;
               SELECT 2;
            "
            );

            // Verify outcome
            Assert.IsNotNull( statements );
            Assert.AreEqual( 4, statements.Count );
        }

        [Test]
        public void Test_Statements_With_Go_Terminators()
        {
            // Exercise
            var statements = ParserFactory.Execute( @"

               SELECT 1
               GO
               SELECT 2
               GO
            "
            );

            // Verify outcome
            Assert.IsNotNull( statements );
            Assert.AreEqual( 4, statements.Count );
            Assert.AreEqual( 2, statements.Count( st => typeof( GoTerminator ).IsAssignableFrom( st.GetType() ) ) );
        }

    }
}