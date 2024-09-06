﻿using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Definition for the kinds of permission escalations.
	/// </summary>
	/// <category>Users and Groups</category>
	/// <override name="PermissionEscalationType" />
	public enum EscalationType : byte {
		/// <summary>
		/// Increase in privileges.
		/// </summary>
		vertical = 1,
		/// <summary>
		/// Increase in access to an object.
		/// </summary>
		horizontal = 2,
	}
	/// <summary>
	/// Used to throw permission escalation exceptions, this is similar to a <see cref="Permission"/>,
	/// but defines a <see cref="before"/> and <see cref="after"/> for a proposed change.
	/// </summary>
	/// <category>Users and Groups</category>
	/// <override name="PermissionEscalation" />
	public class PermissionEscalation {
		/// <summary>
		/// Gets the direction of the escalation.
		/// </summary>
		public EscalationType direction;
		/// <summary>
		/// The <see cref="Company"/> that this permission targets.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company;
		/// <summary>
		/// The type of permission.
		/// </summary>
		public PermissionType kind;
		/// <summary>
		/// Effective permission after the proposed change.
		/// </summary>
		public PermissionEscalationState? after;
		/// <summary>
		/// Effective permission before the proposed change.
		/// </summary>
		public PermissionEscalationState? before;
	}

	/// <summary>
	/// Describes the changes in state that raised the escalation.
	/// </summary>
	/// <category>Users and Groups</category>
	/// <override name="PermissionEscalationState" />
	public class PermissionEscalationState {
		/// <summary>
		/// The level of access defined before the proposed change.
		/// </summary>
		public PermissionLevel? level;
		/// <summary>
		/// Codified names of <see cref="LabelStyle"/>s.
		/// If list is empty, this permission applies for all labels.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string>? labels;
	}
}