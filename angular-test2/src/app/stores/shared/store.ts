export class Store {

    public id: number;
    public name: string;
    public city: string;

    public static parse(json: any): Store {
        return new Store(
            json.id,
            json.name,
            json.city);
    }

    public static parseCollection(json: any): Store[] {
        return json.map(item => {
            return Store.parse(item);
        });
    }

    constructor(
        id: number,
        name: string,
        city: string
    ) {
        this.id = id;
        this.name = name;
        this.city = city;
    }
}
