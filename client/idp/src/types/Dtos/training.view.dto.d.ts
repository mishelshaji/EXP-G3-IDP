declare interface TrainingViewDto {
    /**
     * The unique identifier of the training. This is a read-only property. It
     * will be automatically generated by the server. The client will not be able
     * to set this value. Usually, this is the primary key of the training in the
     * database.
     */
    readonly id: number;

    name: string;

    startDate: Date;

    endDate: Date

    objective: number

    userId: number
    /**
     * The description of the training. It should be a short description of the
     * training and should not exceed 250 characters.
     */
    description: string;

    url: string

    progress: number
}
