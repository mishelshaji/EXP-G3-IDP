declare interface IdpViewDto {
    /**
     * The unique identifier of the idp. This is a read-only property. It
     * will be automatically generated by the server. The client will not be able
     * to set this value. Usually, this is the primary key of the idp in the
     * database.
     */
    readonly id: number;

    /**
     * The name of the idp.
     */
    name: string;

    year: number;

    userId: number;
}
