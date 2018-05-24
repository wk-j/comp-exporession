type Result<'a> =
    | Success of 'a
    | Failure of string

type ResultBuilder() =
    member __.Return a = Success(a)
    member __.Bind(m, f) =
        match m with
        | Success a -> f a
        | Failure m -> Failure m
    member __.TryWith(r, f) =
        try r() with ex -> f ex
    member __.Delay f = f
    member __.Run f = f()
    member __.ReturnFrom r = r

let res = ResultBuilder()

let Combine2 p1 p2 fn = fun a -> res {
  let! x = p1 a
  let! y = p2 a
  try
    return fn(x,y)
  with ex ->
    return! Failure(ex.Message) }

