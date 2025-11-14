main = do
    guest_input <- getLine
    budget_input <- getLine

    let guest = read guest_input :: Int 
    let budget = read budget_input :: Int

    let kozunaci = ceiling ((fromIntegral guest :: Double) / 3.0)
    let eggs = guest * 2

    let total_kozunaci_money = kozunaci * 4
    let total_egg_money = (fromIntegral eggs :: Double) * 0.45

    let total_money_spent = (fromIntegral total_kozunaci_money :: Double) + total_egg_money

    let kozunaci_output = show kozunaci :: String
    let eggs_output = show eggs :: String

    if total_money_spent <= (fromIntegral budget :: Double)
        then do
            let left_money = (fromIntegral budget :: Double) - total_money_spent
            let rounded_left_money = (fromInteger (round (left_money * 100))) / 100
            let left_money_output = show rounded_left_money :: String

            putStrLn("Lyubo bought " ++ kozunaci_output ++ " Easter bread and " ++ eggs_output ++ " eggs.")
            putStrLn("He has " ++ left_money_output ++ " lv. left.")
        else do
            let needed_money = total_money_spent - (fromIntegral budget :: Double)
            let rounded_needed_money =  (fromInteger (round (needed_money * 100))) / 100
            let needed_money_output = show rounded_needed_money :: String

            putStrLn("Lyubo doesn't have enough money.")
            putStrLn("He needs " ++ needed_money_output ++ " lv. more.")
