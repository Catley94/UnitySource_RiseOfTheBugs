﻿// Copyright (c) Supernova Technologies LLC
using System;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Defines a type of <see cref="NavLink"/>.
    /// </summary>
    public enum NavLinkType
    {
        /// <summary>
        /// Navigation is determined based on the navigation direction.
        /// </summary>
        Auto,
        /// <summary>
        /// Manually configure a navigation target for each direction.
        /// </summary>
        Manual,
    }

    /// <summary>
    /// Defines the fallback behavior when a navigation target isn't found.
    /// </summary>
    public enum NavLinkFallback
    {
        /// <summary>
        /// Perform a navigation query for the nearest navigable
        /// element outside the active navigation scope.
        /// </summary>
        NavigateOutsideScope,

        /// <summary>
        /// Don't fire any additional events, and don't try 
        /// to navigate outside the active navigation scope.
        /// </summary>
        DoNothing,

        /// <summary>
        /// Fire events to allow event handlers to choose
        /// how the current state should be handled.
        /// </summary>
        FireDirectionEvent,     
    }

    /// <summary>
    /// Defines the navigation <see cref="Target"/> for a navigation direction. If <c><see cref="Type"/> == <see cref="NavLinkType.Auto"/></c>, 
    /// then the system will attempt to find the nearest navigable element in the designated direction.
    /// </summary>
    [Serializable]
    public struct NavLink : IEquatable<NavLink>
    {
        /// <summary>
        /// A <see cref="NavLink"/> configured for automatic navigation.
        /// </summary>
        public static readonly NavLink Auto = null;

        /// <summary>
        /// A <see cref="NavLink"/> configured to not navigate to anything nor fire any events.
        /// </summary>
        public static readonly NavLink Empty = new NavLink() { Target = null, Type = NavLinkType.Manual, Fallback = NavLinkFallback.DoNothing };

        /// <summary>
        /// The type of navigation associated with this link.
        /// </summary>
        [SerializeField]
        public NavLinkType Type;

        /// <summary>
        /// Designates the fallback behavior in the event a navigation target isn't found or is not configured to be navigable.
        /// </summary>
        [SerializeField]
        public NavLinkFallback Fallback;

        /// <summary>
        /// The navigation target to use when <c><see cref="Type"/> == <see cref="NavLinkType.Manual"/></c>.
        /// </summary>
        [SerializeField]
        public GestureRecognizer Target;

        /// <summary>
        /// Implicit operator.
        /// </summary>
        /// <param name="target">The <see cref="GestureRecognizer"/> to use for manual navigation. If <c>null</c>, then the <see cref="NavLink"/> will be <see cref="NavLink.Auto"/>.</param>
        public static implicit operator NavLink(GestureRecognizer target)
        {
            bool hasTarget = target != null;

            return new NavLink() 
            { 
                Target = target, 
                Type = hasTarget ? NavLinkType.Manual : NavLinkType.Auto,
                Fallback = hasTarget ? NavLinkFallback.DoNothing : NavLinkFallback.NavigateOutsideScope
            };
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><c>true</c> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
        public static bool operator ==(NavLink lhs, NavLink rhs)
        {
            return lhs.Type == rhs.Type && 
                   lhs.Fallback == rhs.Fallback && 
                   lhs.Target == rhs.Target;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><c>true</c> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
        public static bool operator !=(NavLink lhs, NavLink rhs)
        {
            return lhs.Type != rhs.Type ||
                   lhs.Fallback != rhs.Fallback ||
                   lhs.Target != rhs.Target;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="NavLink"/> to compare.</param>
        /// <returns><c>true</c> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(NavLink other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="NavLink"/> to compare.</param>
        /// <returns><c>true</c> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            return other is NavLink link && Equals(link);
        }

        /// <summary>The hashcode for this <see cref="NavLink"/></summary>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Type.GetHashCode();
            hash = (hash * 7) + Fallback.GetHashCode();

            if (Target != null)
            {
                hash = (hash * 7) + Target.GetHashCode();
            }

            return hash;
        }
    }

    internal static class NavLinkExtensions
    {
        public static bool TryGetTarget(ref this NavLink link, out UIBlock target)
        {
            target = null;

            if (link.Type == NavLinkType.Auto || link.Target == null || !link.Target.IsNavigable)
            {
                return false;
            }

            target = link.Target.UIBlock;
            return true;
        }
    }
}
