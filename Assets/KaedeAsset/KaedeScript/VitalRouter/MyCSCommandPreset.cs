using System;
using UnityEngine;
using VitalRouter;

namespace KaedeAsset.KaedeScript.VitalRouter
{
    public class MyCSCommandPreset
    {
        public struct FooCommand : ICommand
        {
            public int X { get; set; }
            public string Y { get; set; }
        }

        public struct BarCommand : ICommand
        {
            public Guid Id { get; set; }
            public Vector3 Destination { get; set; }
        }


    }
}