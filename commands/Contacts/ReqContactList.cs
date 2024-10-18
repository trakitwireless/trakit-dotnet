using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="contact"/>.
	/// </summary>
	public abstract class ReqContactList : Request, IReqIDeletable {
		/// <summary>
		/// When true, the command will also return  deleted <see cref="Contact"/>s.
		/// </summary>
		public bool includeDeleted { get; set; }
	}
	/// <summary>
	/// Contains the <see cref="Company.id"/> of the collection.
	/// </summary>
	public class ReqContactListByCompany : ReqContactList {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
}