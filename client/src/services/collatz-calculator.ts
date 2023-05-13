import {saveAs} from "file-saver"

export class CollatzCalculatorService {
    private apiUrl = "/Conjecture/resolve";

    async calculateSequence(args: calculationArgs): Promise<string[]> {
        const response = await fetch(`${this.apiUrl}?value=${args.value}&multiplier=${args.multiplier}&isSubtraction=${args.isSubtraction}&startInterval=${args.startInterval}&endInterval=${args.endInterval}`);
        const data: string[] = await response.json();
        console.log(data)
        return data;
    }

    async calculateSequenceToFile(args: calculationArgs): Promise<any> {
        const response = await fetch(`${this.apiUrl}`, {
            method: "POST",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(args)
        });
        const data: any = await response.blob();
        saveAs(data, "file.txt");
        console.log(data)
        return data;
    }
}

interface calculationArgs {
    value: string,
    multiplier: number,
    maxIteration: number,
    isSubtraction: boolean,
    startInterval: number,
    endInterval: number
}