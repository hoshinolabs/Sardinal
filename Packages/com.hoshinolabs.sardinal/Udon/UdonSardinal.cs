﻿using HoshinoLabs.Sardinject;
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace HoshinoLabs.Sardinal.Udon {
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    internal sealed class UdonSardinal : ISardinal {
        [Inject(Optional = true), SerializeField, HideInInspector]
        int _0;
        [Inject(Optional = true), SerializeField, HideInInspector]
        object[] _1;
        [Inject(Optional = true), SerializeField, HideInInspector]
        UdonBehaviour[][] _2;
        [Inject(Optional = true), SerializeField, HideInInspector]
        string[][] _3;
        [Inject(Optional = true), SerializeField, HideInInspector]
        string[][][] _4;

        public override void Publish(SignalId id, params object[] args) {
            if (id == null) {
                Debug.LogError("[<color=#47F1FF>Sardinal</color>] Attempting to use an invalid signal id");
                return;
            }
            var signature = $"{((object[])(object)id)[0]}.";
            for (var i = 0; i < args.Length; i++) {
                signature += $"__{args[i].GetType().FullName.Replace(".", "")}";
            }

            var idx = Array.IndexOf(_1, signature);
            if (idx < 0) {
                return;
            }
            var __2 = _2[idx];
            var __3 = _3[idx];
            var __4 = _4[idx];
            for (var i = 0; i < __2.Length; i++) {
                var ___2 = __2[i];
                var ___4 = __4[i];
                for (var j = 0; j < ___4.Length; j++) {
                    ___2.SetProgramVariable(___4[j], args[j]);
                }
                ___2.SendCustomEvent(__3[i]);
            }
        }

        //public override void Subscribe(SignalId signalId, IUdonEventReceiver subscriber) {

        //}
    }
}
