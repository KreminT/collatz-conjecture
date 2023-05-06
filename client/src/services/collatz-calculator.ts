import {saveAs} from "file-saver"

export class CollatzCalculatorService {
    private apiUrl = "/Conjecture/resolve";

    async calculateSequence(n: string, multiplier: number): Promise<string[]> {
        const response = await fetch(`${this.apiUrl}?value=${n}&multiplier=${multiplier}`);
        const data: string[] = await response.json();
        console.log(data)
        return data;
    }

    async calculateSequenceToFile(n: string, multiplier: number, maxIteration: number): Promise<any> {
        const response = await fetch(`${this.apiUrl}`, {
            method: "POST",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({value: n, multiplier: multiplier, maxIteration: maxIteration})
        });
        const data: any = await response.blob();
        saveAs(data, "file.txt");
        console.log(data)
        return data;
    }
}