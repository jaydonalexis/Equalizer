function sampleFrequency = runTransformAudioFile(audioFile)
    NUMBER_OF_DATA_POINTS = 16777216;

    [audioData, sampleFrequency] = audioread(audioFile);
    frequencyVector = linspace(0, sampleFrequency, NUMBER_OF_DATA_POINTS);
    amplitudeVector = abs(fft(audioData, NUMBER_OF_DATA_POINTS));
    figure;
    plot(frequencyVector(1 : NUMBER_OF_DATA_POINTS / 2), amplitudeVector(1 : NUMBER_OF_DATA_POINTS / 2));
    title('Fourier Transform Plot');
    xlabel('Frequency');
    ylabel('Amplitude');
end