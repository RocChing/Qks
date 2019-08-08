import Entity from './entity'

export class Role extends Entity<number>{
    name: string;
    displayName: string;
    normalizedName: string;
    description: string;
    grantedPermissions: string[]
}

export class FlatPermission {
    name: string;
    displayName: string;
    description: string;
    parentName: string;
    expand: boolean;
    checked: boolean;
    children: Array<FlatPermission>
}