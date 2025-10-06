#pragma once
#include "../cnn/all_includes.hpp"

namespace CNN {

    class ConvolutionOperator {
    public:
        gridEntity applyFilter(const gridEntity& input, const gridEntity& filter, int stride);
    };

    class FilterHelper {
    public:
        std::vector<gridEntity> get_all_predefined_filter();
        std::vector<volumetricEntity>& get_all_training_filter();
        gridEntity apply_filter_universal(gridEntity, gridEntity, int);
    };

    class Activation {
    public:
        void activate_feature_map_using_RELU_universal(gridEntity&);
        void activate_feature_map_using_SIGMOID(gridEntity&);
    };

    class Normalization {
    public:
        void apply_normalaization_universal(gridEntity&);
    };

    class Pooling {
    public:
        gridEntity apply_pooling_univeral(gridEntity, int);
        gridEntity unpool_without_indices(gridEntity&, gridEntity&, int, int, int);

    };

    class FilterTrainer {
    public:
        std::vector<volumetricEntity> compute_filter_gradients(
            const std::vector<gridEntity>& inputChannels,
            const std::vector<gridEntity>& outputGradients,
            int stride
        );
        void update_filters_with_gradients(std::vector<volumetricEntity>&, const std::vector<volumetricEntity>&, double learningRate);
    };

    class ConvolutionLayer {
        volumetricEntity inputChannels;
        std::vector<volumetricEntity> filters;
        volumetricEntity outputFeatureMaps;

    public:
        void forward();
        void backward();
    };

} 
// .. and so much more but cant be bothered with ts right now