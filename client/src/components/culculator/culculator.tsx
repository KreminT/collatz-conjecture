import {useState} from "react";
import {CollatzCalculatorService} from "../../services/collatz-calculator";
import styles from "./culculator.module.css"

interface Props {
}

function CollatzCalculator(props: Props) {
    const [number, setNumber] = useState<string>("");
    const [sequence, setSequence] = useState<string[]>([]);
    const [multiplier, setMultiplier] = useState<number>(3);
    const [maxIteration, setMaxIteration] = useState(20000);
    const [isLoading, setLoading] = useState(false);

    const handleCalculate = async () => {
        const calculator = new CollatzCalculatorService();
        setLoading(true)
        setSequence([]);
        if (number.length > 100 || multiplier != 3) {
            await calculator.calculateSequenceToFile(number, multiplier, multiplier != 3 ? maxIteration : 0);
            alert("File downloaded")
        } else {
            const result = await calculator.calculateSequence(number, multiplier);
            setSequence(result);
        }
        setLoading(false)
    };

    return (
        <div className={styles.calculator}>
            <header className={styles.calculatorHeader}>
                <h1 className={styles.calculatorTitle}>Collatz Sequence Calculator</h1>
                <p className={styles.calculatorSubtitle}>Enter a number to calculate its Collatz sequence:</p>
            </header>
            <div className={styles.calculatorBanner}>
                <label htmlFor="number-input">Number: </label>
                <input disabled={isLoading} id="number-input" type="number" className={styles.calculatorInput}
                       value={number}
                       onChange={(e) => setNumber(e.target.value)}/>
                <label htmlFor="multiplier-input">Multiplier: </label>
                <input disabled={isLoading} id="multiplier-input" type="number" className={styles.multiplierInput}
                       value={multiplier}
                       onChange={(e) => setMultiplier(parseInt(e.target.value))}/>
                <span style={{visibility: multiplier == 3 ? "hidden" : "visible"}}>
                    <label htmlFor="iteration-input">Max iteration: </label>
                    <input disabled={multiplier == 3 || isLoading} id="iteration-input" type="number"
                           className={styles.iterationInput} value={maxIteration}
                           onChange={(e) => setMaxIteration(parseInt(e.target.value))}/>
                </span>
                <div className={styles.execute}>
                    <button disabled={isLoading} className={styles.calculatorButton} onClick={handleCalculate}>
                        Calculate
                    </button>
                </div>
            </div>
            {isLoading && (
                <div>Is loading....</div>
            )}
            {sequence.length > 0 && !isLoading && (
                <div className={styles.calculatorOutput}>
                    <p>The Collatz sequence({multiplier}x) for {number} is:</p>
                    {sequence.map((num) => (
                        <div>{num}</div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default CollatzCalculator;