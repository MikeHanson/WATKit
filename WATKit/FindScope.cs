using System;

namespace WATKit
{
	public enum FindScope
	{
		NotSet = 0,
		Self,
		Children,
		Descendants,
		SelfAndChildren,
		SelfAndDescendants,
	}
}
