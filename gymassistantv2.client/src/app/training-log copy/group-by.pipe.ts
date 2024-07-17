import { Pipe, PipeTransform } from '@angular/core';
import { TrainingSet } from '../domain/TrainingSet';

@Pipe({
  name: 'groupBy',
  standalone: true
})
export class GroupByPipe implements PipeTransform {

  transform(collection: TrainingSet[] | undefined, property: string): any[] | null {
    console.log(collection);
    if(!collection){
      return null;
    }
    else{
      const groupedCollection = collection.reduce((previous, current) =>
      {
        if(!previous[current['exercise'][property]]) {
          previous[current['exercise'][property]] = [current];
        }
        else{
          previous[current['exercise'][property]].push(current);
        }
        return previous;
      }, {});

      console.log(Object.keys(groupedCollection).map(key => ({ key, value:
        groupedCollection[key]})));

      return Object.keys(groupedCollection).map(key => ({ key, value:
      groupedCollection[key]}));
    }
  }

}
