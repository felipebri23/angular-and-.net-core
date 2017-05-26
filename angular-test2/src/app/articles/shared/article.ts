export class Article {

    public id: number;
    public description: string;
    public price: number;

    public static parse(json: any): Article {
        return new Article(
            json.id,
            json.description,
            json.price);
    }

    public static parseCollection(json: any): Article[] {
        return json.map(item => {
            return Article.parse(item);
        });
    }

    constructor(
        id: number,
        description: string,
        price: number
    ) {
        this.id = id;
        this.description = description;
        this.price = price;
    }
}
