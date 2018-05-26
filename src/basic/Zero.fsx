type TraceBuilder() =
    member __.Bind(m, f) =
        match m with
        | None ->
            printfn "Binding with None. Exiting"
        | Some a ->
            printfn "Binding with Some(%A). Continuing" a
        Option.bind f m
    member __.Return(x) =
        printfn "Returning a unwrapped %A as an option" x
        Some x
    member __.ReturnFrom(m) =
        printfn "Returning on option (%A) directly" m
        m

let trace = TraceBuilder()

trace {
    return 1
} |> printfn "%A"


trace {
    return! Some 2
} |> printfn "%A"

trace {
    let! x = Some 1
    let! y = Some 2
    return x + y
} |> printfn "%A"

trace {
    let! x = None
    let! y = Some 1
    return x + y
} |> printfn "Result 4: %A"


