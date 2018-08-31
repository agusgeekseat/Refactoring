using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Model
{
    /// <summary>
    /// membership enum
    /// </summary>
    public enum Membership
    {
        NonMember,
        Silver,
        Gold,
        Platinum
    }

    /// <summary>
    /// Member class
    /// </summary>
    public class Member
    {
        public Member()
        {
        }

        /// <summary>
        /// Custom custroctor
        /// </summary>
        /// <param name="membership"></param>
        /// <param name="statrDate"></param>
        public Member(Membership membership)
        {
            Membership = membership;
        }

        public string Name { get; set; }

        public Membership Membership { get; set; }

        public DateTime StartDate { get; set; }
    }

    /// <summary>
    /// Silver member class
    /// </summary>
    public class SilverMember : Member
    {
        public SilverMember() : base (Membership.Silver)
        {
        }
    }

    /// <summary>
    /// GOld member class
    /// </summary>
    public class GoldMember : Member
    {
        public GoldMember() : base (Membership.Gold)
        {
        }
    }

    /// <summary>
    /// Platinum member class
    /// </summary>
    public class PlatinumMember : Member
    {
        public PlatinumMember() : base (Membership.Platinum)
        {
        }
    }
}
