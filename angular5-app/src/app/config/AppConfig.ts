import { Injectable } from '@angular/core';
@Injectable()
export class AppConfig {
    private _config: {[key: string]: string};
    constructor(){
        this._config = {
            PathAPI: 'http://localhost:50498/api/'
        };
    }

    // implements get property which takes key/value structure and
    // a simple method to get access to the same value. This way it
    // will be easy to get values just calling this.config.setting['PathAPI']

    get setting():{ [key: string]: string} {
        return this._config;
    }

    get(key: any){
        return this._config[key];
    }
}