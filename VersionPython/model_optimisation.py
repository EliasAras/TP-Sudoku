from tensorflow import keras
from keras.layers import Activation
from keras.layers import Conv2D, BatchNormalization, Dense, Flatten, Reshape





def train_model(x_train, y_train, batch_size=64, ep=2):
    
    print("action en cours chez: train_model()")

    model = keras.models.Sequential()
#    kernel_size=(9,1)
#    change stryding
#    64, 128 = nb noyaux
    
    model.add(Conv2D(64, kernel_size=(3,3), strides = (3,3),activation='relu', padding='same', input_shape=(9,9,1)))
    model.add(BatchNormalization())
    model.add(Conv2D(64, kernel_size=(9,1), activation='relu', padding='same'))
    model.add(Conv2D(64, kernel_size=(1,9), activation='relu', padding='same'))
    model.add(BatchNormalization())
    model.add(Conv2D(128, kernel_size=(1,1), activation='relu', padding='same'))

    model.add(Flatten())
    model.add(Dense(81*9))
    model.add(Reshape((-1, 9)))
    model.add(Activation('softmax'))
    
    adam = keras.optimizers.adam(lr=.001)
    model.compile(loss='sparse_categorical_crossentropy', optimizer=adam)

    print(model.fit(x_train, y_train, batch_size=batch_size, epochs=ep))

    model.save('sudoku_test.model')
    print("action terminee chez: train_model()")
    
#    score = model.evaluate(x_test, y_test, verbose=0)
#    print('Test loss:', score[0])
#    print('Test accuracy:', score[1])
    
    




