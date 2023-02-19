declare interface ActionViewDto {
    /**
     * The unique identifier of the action. This is a read-only property. It
     * will be automatically generated by the server. The client will not be able
     * to set this value. Usually, this is the primary key of the action in the
     * database.
     */
    readonly id: number;

    /**
     * The name of the action.
     */
    name: string;

    endDate: Date;

    objective: number;

    userId: number;

    /**
     * The description of the action.
     */
    description: string;
}
