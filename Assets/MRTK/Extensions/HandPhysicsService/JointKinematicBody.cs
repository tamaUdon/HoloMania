// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using Unity.Profiling;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Extensions.HandPhysics
{
    /// <summary>
    /// Updates a rigidbody transform against another transform.
    /// </summary>
    public class JointKinematicBody : MonoBehaviour
    {
        /// <summary>
        /// The joint this component tracks.
        /// </summary>
        public Transform Joint { get; set; }

        /// <summary>
        /// What hand this component lives on.
        /// </summary>
        public Handedness HandednessType { get; set; }

        /// <summary>
        /// What joint this component lives on.
        /// </summary>
        public TrackedHandJoint JointType { get; set; }

        /// <summary>
        /// An event to subscribe to when the component get's enabled. Useful for tacking when the joint loses tracking.
        /// </summary>
        public Action<JointKinematicBody> OnEnableAction { get; set; }

        /// <summary>
        /// An event to subscribe to when the component get's disabled. Useful for tacking when the joint loses tracking.
        /// </summary>
        public Action<JointKinematicBody> OnDisableAction { get; set; }

        /// <summary>
        /// self body
        /// </summary>
        public GameObject _player;
        public GameObject _effect;
        private GameObject mEffect;

        private static readonly ProfilerMarker UpdateStatePerfMarker = new ProfilerMarker("[MRTK] JointKinematicBody.UpdateState");
        
        /// <summary>
        /// 手とオブジェクトが当たった時にサウンドを再生する
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerEnter(Collider other)
        {
            if (_player && _player == other.gameObject)
            {
                return;
            }

            if (other.gameObject.tag.Contains("Cube"))
            {
                GetComponent<AudioSource>().Play();
                mEffect = Instantiate(_effect, this.transform.position, Quaternion.identity);
                mEffect.transform.localScale = Vector3.one;
                Invoke(nameof(DestroyEffect), 3.0f); // 3秒後に破棄
            }
        }

        void DestroyEffect()
        {
            Destroy(mEffect);
        }


        /// <summary>
        /// Updates the position of the <see cref="JointKinematicBody"/> based on <see cref="JointType"/>.
        /// </summary>
        public void UpdateState(bool active)
        {
            using (UpdateStatePerfMarker.Auto())
            {
                bool previousActiveState = gameObject.activeSelf;
                gameObject.SetActive(active);

                if (active)
                {
                    transform.position = Joint.position;
                    transform.rotation = Joint.rotation;
                }

                if (previousActiveState != active)
                {
                    if (active)
                    {
                        OnEnableAction?.Invoke(this);
                    }
                    else
                    {
                        OnDisableAction?.Invoke(this);
                    }
                }
            }
        }
    }
}
