function [trebleWeight, bassWeight, bandWeight] = runFilters(audioFile)
    LOW_CUTOFF = 250;
    HIGH_CUTOFF = 4000;
    FILTER_ORDER = 2;

    [originalAudio, sampleFrequency] = audioread(audioFile);

    [B, A] = butter(FILTER_ORDER, HIGH_CUTOFF / (sampleFrequency / 2), 'high');
    [D, C] = butter(FILTER_ORDER, LOW_CUTOFF / (sampleFrequency / 2), 'low');
    [F, E] = butter(FILTER_ORDER, [(LOW_CUTOFF / (sampleFrequency / 2)), (HIGH_CUTOFF / (sampleFrequency / 2))], 'bandpass');

    trebleFilteredAudio = filter(B, A, originalAudio);
    bassFilteredAudio = filter(D, C, originalAudio);
    bandFilteredAudio = filter(F, E, originalAudio);

    trebleWeight = (mean(mean(abs(trebleFilteredAudio)))) / (mean(mean(abs(originalAudio))));
    bassWeight = (mean(mean(abs(bassFilteredAudio)))) / (mean(mean(abs(originalAudio))));
    bandWeight = (mean(mean(abs(bandFilteredAudio)))) / (mean(mean(abs(originalAudio))));
end
