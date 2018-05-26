

type ListWorkflowBuilder() =
    member __.Bind(list, f) =
        list |> List.collect f

    member __.Return(x) =
        [x]

let l = new ListWorkflowBuilder()

()