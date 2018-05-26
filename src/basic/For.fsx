type ListBuilder() =
    member __.Bind(m, f) =
        m |> List.collect f

    member __.Zero() =
        printfn "Zero"
        []

    member __.Return(x) =
        printfn "Return an unwrapped %A as a list" x
        [x]

    member __.Yield(x) =
        printfn "Yield an unwrapped %A as a list" x
        [x]

    member this.For(m, f) =
        printfn "For %A" m
        this.Bind(m, f)

let listBuilder = new ListBuilder()

listBuilder {
    let! x = [1..3]
    let! y = [10;20;30]
    return x + y
} |> printfn "%A"

listBuilder {
    for x in [1..3] do
    for y in [10;20;30] do
        return x + y
} |> printfn "%A"
