import { Pipe, PipeTransform } from "@angular/core";

@Pipe({name : 'paginate'})
export class PaginationPipe implements PipeTransform {
    transform(value: string, length = 4) {
        return value.slice(0,length);
    }
}