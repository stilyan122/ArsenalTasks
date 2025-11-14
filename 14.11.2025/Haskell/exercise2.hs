main = do
    working_days_input <- getLine
    earned_daily_money_input <- getLine

    let working_days = read working_days_input :: Int
    let daily_money = read earned_daily_money_input :: Double

    let levas = daily_money * 1.59
    let total_earned = levas * fromIntegral working_days :: Double
    let total_earned_output = show total_earned :: String

    putStrLn("a) Ivan poluchava " ++ total_earned_output ++ "lv. na mesec.")

    let vats = 0.25 * total_earned
    let money_after_vats = total_earned - vats

    let vats_output = show vats :: String
    let money_after_vats_output = show money_after_vats :: String

    putStrLn("b) Sled udarjaneto na danacite: " ++ vats_output ++ "lv., na Ivan mu ostavat " ++ money_after_vats_output ++ "lv.")