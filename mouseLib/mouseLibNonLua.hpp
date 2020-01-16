#pragma once
#include <windows.h>

namespace mouse_funcs {

	INPUT Inputs[1] = { 0 };

	void setup() {
		Inputs[0].type = INPUT_MOUSE;
	}

	void leftButtonDown() {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN;
		SendInput(1, Inputs, sizeof(INPUT));
	}

	void leftButtonUp() {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP;
		SendInput(1, Inputs, sizeof(INPUT));
	}

	void rightButtonDown() {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_RIGHTDOWN;
		SendInput(1, Inputs, sizeof(INPUT));
	}

	void rightButtonUp() {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_RIGHTUP;
		SendInput(1, Inputs, sizeof(INPUT));
	}

	void leftButtonPress(float n) {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN;
		SendInput(1, Inputs, sizeof(INPUT));
		Sleep(n);
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP;
		SendInput(1, Inputs, sizeof(INPUT));
	}

	void rightButtonPress(float n) {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN;
		SendInput(1, Inputs, sizeof(INPUT));
		Sleep(n);
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP;
		SendInput(1, Inputs, sizeof(INPUT));
	}

	void mouseScroll(int amount) {
		Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_HWHEEL;
		Inputs[0].mi.mouseData = amount;
		SendInput(1, Inputs, sizeof(INPUT));
		Inputs[0].mi.mouseData = NULL;
	}

	void moveMouseRelative(LONG x, LONG y) {
		POINT p;
		if (GetCursorPos(&p))
		{
			Inputs[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
			Inputs[0].mi.dx = ((p.x + x) * 0xFFFF / GetSystemMetrics(SM_CXSCREEN) + 1);
			Inputs[0].mi.dy = ((p.y + y) * 0xFFFF / GetSystemMetrics(SM_CYSCREEN) + 1);
			SendInput(1, Inputs, sizeof(INPUT));
		}
	}

}

namespace keyboard_funcs {

	INPUT Inputs[1] = { 0 };

	void setup() {
		Inputs[0].type = INPUT_KEYBOARD;
	}

	void keyPress(WORD key) {
		Inputs[0].ki.wVk = key;
		SendInput(1, Inputs, sizeof(INPUT));
		Inputs[0].ki.wVk = NULL;
	}

	void keyRelease(WORD key) {
		Inputs[0].ki.wVk = key;
		Inputs[0].mi.dwFlags = KEYEVENTF_KEYUP;
		SendInput(1, Inputs, sizeof(INPUT));
		Inputs[0].mi.dwFlags = NULL;
		Inputs[0].ki.wVk = NULL;
	}

	void keyTap(WORD key, int delay) {
		Inputs[0].ki.wVk = key;
		SendInput(1, Inputs, sizeof(INPUT));
		Sleep(delay);
		Inputs[0].mi.dwFlags = KEYEVENTF_KEYUP;
		SendInput(1, Inputs, sizeof(INPUT));
		Inputs[0].mi.dwFlags = NULL;
		Inputs[0].ki.wVk = NULL;
	}

}