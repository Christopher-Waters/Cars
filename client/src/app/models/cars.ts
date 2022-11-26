export interface ICars {
    [x: string]: any;
    filter(arg0: (element: any) => boolean): any;
    id: number;
    name: string;
    year: number;
    make: string;
}