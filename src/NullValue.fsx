let (|Null|NotNull|) (x : 'T when 'T : not struct) =
    if obj.ReferenceEquals(x, null) then Null else NotNull x

// Examples

// throws nullreference exception
match [Unchecked.defaultof<int ref>] with
| [{ contents = 42 }] -> true
| _ -> false

// evaluates to 1
match [Unchecked.defaultof<int ref>] with
| [NotNull { contents = 42 }] -> 0
| [Null] -> 1
