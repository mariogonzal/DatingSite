import {Photo} from './photo';

export interface User {
    id: number;
    username: string;
    gender: string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive: Date;
    city: string;
    country: string;
    interest?: string;
    lookingFor?: string;
    introduction?: string;
    photoUrl: string;
    photos: Photo[];

}
