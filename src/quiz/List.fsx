type ListWorkflowBuilder() =
    member __.Bind(list, f) =
        list |> List.collect f

    member __.Return(x) =
        [x]

let l = new ListWorkflowBuilder()


l.Bind([1;2;3], fun x -> (
    l.Bind([10;11;12], fun y -> (
        l.Return(x + y)
    ))
))

|> printfn "%A"

let added =
    l {
        let! i = [1;2;3]
        let! j = [10;11;12]
        return i+j
        }

printfn "added=%A" added