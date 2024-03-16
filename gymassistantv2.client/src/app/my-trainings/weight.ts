export class Weight{
    weightInput: number;
    weightDropDown: number;

    constructor(weightInput: number = 0, weightDropdown: number = 0){
        this.weightInput = weightInput;
        this.weightDropDown = weightDropdown;
    }

    CombineWeight(): number{
        return Number(this.weightInput) + Number(this.weightDropDown)
        
    }
}