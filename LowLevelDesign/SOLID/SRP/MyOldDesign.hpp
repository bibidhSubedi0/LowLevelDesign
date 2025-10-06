#pragma once
#include "../cnn/all_includes.hpp"


/* I dont knw why my stuid ass had the bright idea to not name the paramaters, but here we are*/
class ConvolutionLayers
{
    gridEntity raw_image;
    std::vector<gridEntity> predefined_filters;
    std::vector<gridEntity> feature_maps;
    std::vector<gridEntity> pool_maps;
    std::vector<gridEntity> trained_filters;
    int no_of_filters_in_second_CL;
    volumetricEntity input_channels;
    std::vector<volumetricEntity> training_filters;
    volumetricEntity ouput_feature_maps;
    std::vector<gridEntity> final_pool_maps;
    int no_of_filters_used;

    public:
	ConvolutionLayers(gridEntity);

    std::vector<gridEntity> get_all_predefined_filter();
    std::vector<volumetricEntity>& get_all_training_filter();

    gridEntity get_raw_input_image();
    std::vector<gridEntity>& get_feature_map();
    volumetricEntity& get_input_channels();
    volumetricEntity& get_output_feature_maps();
    std::vector<gridEntity>& get_final_pool_maps();
    std::vector<gridEntity>& get_pool_map();
    
    gridEntity apply_filter_universal(gridEntity, gridEntity, int);
    void activate_feature_map_using_RELU_universal(gridEntity&);
    void activate_feature_map_using_SIGMOID(gridEntity&);
    void apply_normalaization_universal(gridEntity&);
    gridEntity apply_pooling_univeral(gridEntity, int);
    gridEntity unpool_without_indices(gridEntity&, gridEntity&, int, int, int);
    std::vector<volumetricEntity> compute_filter_gradients(
        const std::vector<gridEntity>& inputChannels,
		const std::vector<gridEntity>& outputGradients,
		int stride
	);
    void update_filters_with_gradients(std::vector<volumetricEntity>&, const std::vector<volumetricEntity>&, double learningRate);
};
