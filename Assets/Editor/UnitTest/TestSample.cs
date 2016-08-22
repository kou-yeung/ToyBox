using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.EditorTests;
using System;

public class TestSample
{
    [TestCase]
    public void Test()
    {
        Assert.AreEqual(3, 1 + 2);
    }
}
