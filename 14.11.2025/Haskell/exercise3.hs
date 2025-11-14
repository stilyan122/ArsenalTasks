main = do
    count_of_ski_men_input <- getLine
    let count_of_ski_men = read count_of_ski_men_input :: Int

    jackets_input <- getLine
    hats_input <- getLine
    shoes_input <- getLine

    let jackets = read jackets_input :: Int
    let hats = read hats_input :: Int
    let shoes = read shoes_input :: Int

    let total_money_spent = (fromIntegral count_of_ski_men :: Double) * ((fromIntegral jackets :: Double) * 120.0 + (fromIntegral hats :: Double) * 75.0 + (fromIntegral shoes :: Double) * 299.90) 

    let total_money_spent_output = show total_money_spent :: String

    putStrLn("Suma za vsichki skiori: " ++ total_money_spent_output)

    let money_discount = 0.15 * total_money_spent
    let total_money_after_discount = total_money_spent - money_discount

    let money_discount_output = show money_discount :: String
    let total_money_after_discount_output = show total_money_after_discount :: String
    
    putStrLn("Sled namalenie ot " ++ money_discount_output ++ "lv. trqbva da zaplatite " ++ total_money_after_discount_output ++ "lv.")