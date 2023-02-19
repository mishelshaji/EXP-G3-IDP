declare interface TrainingCreateDto {
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

    progress: number}
